using Practies.Core.Services.Interface;
using Practies.DataLayer.Context;
using Practies.DataLayer.Entities.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practies.Core.Services
{
    public class CourseService : ICourseService
    {
        PractiesContext _context;
        public CourseService(PractiesContext context)
        {
            this._context = context;
        }

        public List<CourseGroup> GetAllGroup()
        {
            return _context.CourseGroups.ToList();
        }
    }
}
