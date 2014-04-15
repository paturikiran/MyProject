using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDR.Web.Api;

namespace CDR.Web.Models
{
    public class AssignmentNotes : INotes
    {
        private IApiRepository<AssignmentNotes> apiInstance;
        public int ASSIGNMENT_NOTES_ID { get; set; }
        public int ASSIGNMENT_ID { get; set; }
        public string NOTE { get; set; }
        public System.DateTime NOTE_DATE { get; set; }

        public AssignmentNotes()
        {
            apiInstance = new ApiRepository<AssignmentNotes>();
        }
        public IEnumerable<AssignmentNotes> Get(int assignmentId)
        {
            var url = Constants.GETNOTES + assignmentId;
            var notes = apiInstance.Get(url);
            return notes.OrderByDescending(x => x.ASSIGNMENT_NOTES_ID);
        }

        public bool SaveNotes(AssignmentNotes notes)
        {
            return apiInstance.Insert(notes, Constants.CREATENOTES);
        }
    }
}