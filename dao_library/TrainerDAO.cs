using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_library;


namespace dao_library
{
    public class TrainerDAO
    {
        public Trainer CreateTrainer(Trainer trainer)
        {
            MockDatabase.Trainers.Add(trainer);
            return trainer;
        }

        public Trainer? ReadTrainerByName(string name)
        {
            return MockDatabase.Trainers.FirstOrDefault(s => s.Name == name);
        }

        public List<Trainer> ReadTrainers()
        {
            return MockDatabase.Trainers;
        }

        public bool UpdateTrainer(Trainer updatedTrainer)
        {
            var existingTrainer = ReadTrainerByName(updatedTrainer.Name);

            if (existingTrainer != null)
            {
                existingTrainer.Name = updatedTrainer.Name;

                return true;
            }

            return false;
        }

        public bool DeleteCourse(string name)
        {
            var courseToDelete = ReadTrainerByName(name);

            if (courseToDelete != null)
            {
                MockDatabase.Trainers.Remove(courseToDelete);
                return true;
            }

            return false;
        }
    }
}

