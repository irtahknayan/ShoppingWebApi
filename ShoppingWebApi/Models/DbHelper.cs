using ShoppingWebApi.EfCore;

namespace ShoppingWebApi.Models
{
    public class DbHelper
    {
        private DataContext _context;

        public DbHelper(DataContext context)
        {
            _context = context;
        }

        public List<ProductModel> GetProducts()
        {

            List<ProductModel> response = new List<ProductModel>();
            var dataList = _context.Products.ToList();
            dataList.ForEach(row => response.Add(new ProductModel()
            {
                brand = row.brand,
                name = row.name,
                price = row.price,
                size = row.size,
                id = row.id
            }));


            return response;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel response = new ProductModel();
            var row = _context.Products.Where(d => d.id.Equals(id)).FirstOrDefault();
            return new ProductModel()
            {
                brand = row.brand,
                id = row.id,
                name = row.name,
                price = row.price,
                size = row.size
            };
        }

        /// <summary>
        /// It serves the POST/PUT/PATCH
        /// </summary>
        public void SaveOrder(OrderModel orderModel)
        {
            Order dbRecord = new Order();
            if (orderModel.id > 0)
            {
                //PUT
                dbRecord = _context.Orders.Where(d => d.id.Equals(orderModel.id)).FirstOrDefault();
                if (dbRecord != null)
                {
                    dbRecord.Phone = orderModel.Phone;
                    dbRecord.address = orderModel.address;
                }
            }
            else
            {
                //POST
                dbRecord.Phone = orderModel.Phone;
                dbRecord.address = orderModel.address;
                dbRecord.name = orderModel.name;
                dbRecord.Product = _context.Products.Where(f => f.id.Equals(orderModel.product_id)).FirstOrDefault();
                _context.Orders.Add(dbRecord);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Where(d => d.id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
