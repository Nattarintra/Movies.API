using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Movies.Core.DomainContracts
{
    public interface IMovieRepository
    {
        //  แล้วทำไมชื่อใน Repository ถึงใช้ Add/Update/Remove? เพราะ Repository เป็นแค่ ตัวกลางที่ทำงานกับฐานข้อมูลโดยตรง
        //  มัน ไม่รู้เรื่อง HTTP เลย ว่าข้อมูลมาจาก POST, PUT หรือ DELETE
        Task<IEnumerable<Movie>> GetAllAsync();   // ดึงหนังทั้งหมด
        Task<Movie> GetAsync(Guid id);            // ดึงหนังตาม id
        Task<bool> AnyAsync(Guid id);            // ตรวจสอบว่ามีหนัง id นี้ไหม
        void Add(Movie movie);                  // เพิ่มหนัง
        void Update(Movie movie);               // อัปเดตหนัง
        void Remove(Movie movie);              // ลบหนัง
    }
}
