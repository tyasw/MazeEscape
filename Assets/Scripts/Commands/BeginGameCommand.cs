using System.Collections.Generic;

namespace Assets.Scripts.Commands {
    public class BeginGameCommand : Command {
        private void Start() {
            ClassFactory classFactory = ClassFactory.GetInstance();
            Subjects = new List<Subject>();
            Subject Event = classFactory.GetStartGameEvent();
            Subjects.Add(Event);
        }

        public override void Run() {
            base.Run();
        }

        public override string ToString() {
            return "BeginGameCommand";
        }
    }
}
