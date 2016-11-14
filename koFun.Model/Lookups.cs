using System.Collections.Generic;

namespace koFun.Model
{
    public class Lookups
    {
        public int Id { get; set; }
        public IList<Room> Rooms { get; set; }
        public IList<TimeSlot> TimeSlots { get; set; }
        public IList<Track> Tracks { get; set; }
    }
}