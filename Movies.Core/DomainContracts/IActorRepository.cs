using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.DomainContracts
{
    // หน้าที่: เป็น “สัญญา” หรือ Contract ว่า Repository ของ Actor ต้องมีความสามารถอะไรบ้าง
    public interface IActorRepository
    {
        // หน้าที่: จัดการข้อมูลนักแสดง (Actor) ในฐานข้อมูล
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor?> GetAsync(Guid id);
        Task<bool> AnyAsync(Guid id);
        void Add(Actor actor);
        void Update(Actor actor);
        void Remove(Actor actor);
    }
}
