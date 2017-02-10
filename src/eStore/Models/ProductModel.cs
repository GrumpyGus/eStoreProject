using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace eStore.Models
{
    public class ProductModel
    {
        private AppDbContext _db;

        /// <summary>
        /// constructor should pass instantiated DbContext
        /// <summary>
        public ProductModel(AppDbContext context)
        {
            _db = context;
        }

        public List<Product> GetAll()
        {
            return _db.Products.ToList();
        }
        public List<Product> GetAllByBrand(int id)
        {
            return _db.Products.Where(item => item.BrandId == id).ToList();
        }

        public List<Product> GetAllByBrandName(string brandName)
        {
            Brand brand = _db.Brands.First(br => br.Name == brandName);
            return _db.Products.Where(item => item.BrandId == brand.Id).ToList();
        }
    }
}
