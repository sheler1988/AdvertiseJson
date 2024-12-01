using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Models;

public class ImageBoxContainer : InputItem
{
    public int Row { get; set; }
    public int Columns { get; set; }
    public List<Box> Boxes { get; set; }
}