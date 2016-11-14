using System.ComponentModel.DataAnnotations;

namespace koFun.Model
{
    public class SessionBrief
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        public string Code { get; set; }
        public int SpeakerId { get; set; }
        public int TrackId { get; set; }
        public int TimeSlotId { get; set; }
        public int RoomId { get; set; }
        public string Level { get; set; }
        public string Tags { get; set; }
    }
}