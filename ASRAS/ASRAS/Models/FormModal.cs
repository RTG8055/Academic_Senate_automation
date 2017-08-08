using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*EXPLANATION
Only one model can be linked to a single view. This model contains, as data members, all the other models that are required for
the functioning of the form. This solves the problem of views that require more than one model to function, such as the dropdown
views.
 */

namespace ASRAS.Models
{
    public class FormModal
    {
        public Proposal proposal { get; set; }
        public InstituteViewModal instituteViewModal { get; set; }
        public DepartmentViewModal departmentViewModal { get; set; }
        public CourseViewModal courseViewModal { get; set; }
        public SemesterViewModal semesterViewModal { get; set; }
        public SubjectViewModal subjectViewModal { get; set; }
    }
}