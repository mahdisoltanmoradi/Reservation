using Practies.DataLayer.Entities.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practies.Core.Services.Interface
{
    public interface ICourseService
    {
        List<CourseGroup> GetAllGroup();
    }
}
