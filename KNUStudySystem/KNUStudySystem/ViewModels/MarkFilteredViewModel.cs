using KNUStudySystem.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace KNUStudySystem.ViewModels
{
    public class MarkFilteredViewModel
    {
        public bool Ascending { get; set; }
        public string SortBy { get; set; }
        public List<Filter> Filters { get; set; }
        public List<Mark> Marks { get; set; }
    }
    public class Filter
    {
        public string Property { get; set; }
        public string Value { get; set; }
    }
}