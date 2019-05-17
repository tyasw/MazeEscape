using System.Collections.Generic;

namespace Assets.Scripts.Commands {
    public class FinishGameCommand : Command {
        private void Awake() {
            ClassFactory classFactory = ClassFactory.GetInstance();
            Subjects = new List<Subject>();
            Subject Event = classFactory.GetGameData();
            Subjects.Add(Event);
        }

        public override void Run() {
            GameData gameData = Subjects[0] as GameData;
            gameData.GameWon = true;
            base.Run();
        }

        public override string ToString() {
            return "WonGameCommand";
        }
    }
}
