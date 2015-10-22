using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AutoMapper;
using SoftUniContests.BusinessObjects.Models;

[assembly: PreApplicationStartMethod(typeof(SoftUniContests.DAL.DALStartup), "Start")]
namespace SoftUniContests.DAL
{
    public class DALStartup
    {
        public static void Start()
        {
            Mapper.CreateMap<Contest, ContestModel>();
            Mapper.CreateMap<ContestModel, Contest>();

            Mapper.CreateMap<Picture, PictureModel>();
            Mapper.CreateMap<PictureModel, Picture>();
        }
    }
}
