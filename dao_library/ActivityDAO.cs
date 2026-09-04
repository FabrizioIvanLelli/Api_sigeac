using entity_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dao_library
{
    internal class ActivityDAO
    {
        public Activity CreateActivity(Activity activity)
        {
            MockDatabase.Activities.Add(activity);
            return activity;
        }

        public Activity? ReadActivityByTitle(string title)
        {
            return MockDatabase.Activities.FirstOrDefault(s => s.Title == title);
        }

        public List<Activity> ReadActivities()
        {
            return MockDatabase.Activities;
        }

        public bool UpdateActivity(Activity updatedActivity)
        {
            var existingActivity = ReadActivityByTitle(updatedActivity.Title);

            if (existingActivity != null)
            {
                existingActivity.Title = updatedActivity.Title;
            }

            return false;
        }

        public bool DeleteActivity(string title)
        {
            var activityToDelete = ReadActivityByTitle(title);

            if (activityToDelete != null)
            {
                MockDatabase.Activities.Remove(activityToDelete);
                return true;
            }

            return false;
        }
    }
}
