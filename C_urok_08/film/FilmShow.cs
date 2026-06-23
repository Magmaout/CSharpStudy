namespace CSharpStudy.C_urok_08.film {
    internal struct FilmShow {
        public string FilmName;
        public string Hall;
        public DateTime ShowDate;
        public int SeatsCount;
        public double TicketPrice;
        public string Info => FilmName + ", " + Hall + ", " + ShowDate + ", мест: " + SeatsCount + ", билет: " + TicketPrice;
        public FilmShow(string filmName, string hall, DateTime showDate, int seatsCount, double ticketPrice) {
            FilmName = filmName; Hall = hall; ShowDate = showDate; SeatsCount = seatsCount; TicketPrice = ticketPrice;
        }
        public double GetIncome(int peopleCount = -1) {
            if (peopleCount < 0) peopleCount = SeatsCount;
            if (peopleCount > SeatsCount) peopleCount = SeatsCount;
            return peopleCount * TicketPrice;
        }
    }
}
