using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OTMST.Models
{
    public class ArtisansMetadata
    {
        public IEnumerable<string> Images { get; set; }
    }
}