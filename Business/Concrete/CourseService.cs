using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        public CourseService(IGenericDal<Course> genericDal) : base(genericDal)
        {
        }
    }
}
