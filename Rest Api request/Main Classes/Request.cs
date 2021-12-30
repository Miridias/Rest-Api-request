using ConsoleTables;
using Newtonsoft.Json;
using Rest_Api_request.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;

namespace Rest_Api_request.Main_Classes
{
    class Request : IRequest
    {
        private List<Product> _product = new();
        private List<Category> _category = new();
        private WebClient _url = new();
        public void ProcessingRequest()
        {
            string adress = "http://tester.consimple.pro";
            string site = _url.DownloadString(adress);

            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(site);
            DataTable products = dataSet.Tables["Products"];
            DataTable categories = dataSet.Tables["Categories"];

            foreach (DataRow item in products.Rows)
            {

                _product.Add(new Product { Id = int.Parse(item["Id"].ToString()), Name = item["Name"].ToString(), CategoryId = int.Parse(item["CategoryId"].ToString()) });
            }

            foreach (DataRow item in categories.Rows)
            {
                _category.Add(new Category { Id = int.Parse(item["Id"].ToString()), Name = item["Name"].ToString() });
            }

            var result = from p in _product
                         join t in _category on p.CategoryId equals t.Id
                         select new { Name = p.Name, Category = t.Name };

            var table = new ConsoleTable("Product name", "Category name");
            foreach (var item in result)
            {
                table.AddRow(item.Name, item.Category);
            }
            table.Write();
            Console.WriteLine();
        }
    }
}
