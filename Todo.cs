using System;

namespace TodoListApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string TenCongViec { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
