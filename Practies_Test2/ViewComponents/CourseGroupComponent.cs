using Microsoft.AspNetCore.Mvc;
using Practies.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practies_Test2.ViewComponents
{
    public class CourseGroupComponent : ViewComponent
    {
        ICourseService _courseService;

        public CourseGroupComponent(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult) View("CourseGroup",_courseService.GetAllGroup()));
        }

    }
}
