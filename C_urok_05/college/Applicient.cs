namespace CSharpStudy.C_urok_05.college {
    internal class Applicant {
        public string FullName { get; }
        public double AverageMark { get; }
        public int AchievementPoints { get; }
        public DateTime ApplyDate { get; }

        public Applicant(string fullName, double averageMark, int achievementPoints, DateTime applyDate) {
            FullName = fullName;
            AverageMark = averageMark;
            AchievementPoints = achievementPoints;
            ApplyDate = applyDate;
        }
        public static bool operator >(Applicant a, Applicant b) => a.AverageMark == b.AverageMark ? a.AchievementPoints > b.AchievementPoints : a.AverageMark > b.AverageMark;
        public static bool operator <(Applicant a, Applicant b) => a.AverageMark == b.AverageMark ? a.AchievementPoints < b.AchievementPoints : a.AverageMark < b.AverageMark;
    }
}
