using Core.Common.Core;

namespace CarRental.Client.Entities
{
    public class Reservation : ObjectBase
    {
        private int reservationId;
        private int accountId;
        public int ReservationId
        {
            get { return reservationId; }
            set
            {
                if(reservationId != value)
                {
                    reservationId = value;
                    OnPropertyChanged(() => ReservationId);
                }
            }
        }
        public 
    }
}
