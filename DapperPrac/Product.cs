﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPrac;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; } 
    public decimal Price { get; set; }
    public int CategoryID { get; set; }
    public int OnSale { get; set; }
    public string StockLevel { get; set; }
}
