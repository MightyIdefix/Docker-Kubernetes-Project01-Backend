using DISPBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DISPBackEnd.Controllers
{
    [Route("Api/[controller]")]
    public class HaandVaerkerController : ControllerBase
    {
        [HttpPost("AddHaendvaerker")]
        public async Task<ActionResult<HaandVaerker>> AddHaendVaerker([FromBody]HaandVaerker haandVaerker)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var something = db.HaandVaerkers.Where(f => f.FirstName == "Zabih").ToListAsync();
                    db.HaandVaerkers.Add(haandVaerker);
                    await db.SaveChangesAsync();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut("UpdateHaendvaerker")]
        public async Task<ActionResult<HaandVaerker>> UpdateHaendVaerker([FromBody] HaandVaerker haandVaerker)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var handyMan = await db.HaandVaerkers.FirstOrDefaultAsync(f => f.FirstName == haandVaerker.FirstName);
                    if (handyMan != null)
                    {
                        handyMan.FirstName = haandVaerker.FirstName;
                        handyMan.LastName = haandVaerker.LastName;
                        handyMan.Speciality = haandVaerker.Speciality;
                        handyMan.EmployeeDate = haandVaerker.EmployeeDate;
                        db.Update(handyMan);
                        await db.SaveChangesAsync();
                        return handyMan;
                    }
                    return null;
                }
            }
            catch (Exception e) 
            {
                return null;
            }
        }


        [HttpDelete("DeleteHaendvaerker")]
        public async Task<ActionResult<HaandVaerker>> DeleteHaendVaerker([FromBody] HaandVaerker haandVaerker)
        {
            using (var db = new DBContext())
            {
                var handyMan = await db.HaandVaerkers.FirstOrDefaultAsync(f => f.FirstName == haandVaerker.FirstName);
                if (handyMan != null)
                {
                    db.Remove(handyMan);
                    await db.SaveChangesAsync();
                    return handyMan;
                }
            }
            return null;
        }

        [HttpGet("GetHaandvaerker")]
        public async Task<ActionResult<HaandVaerker>> GetHaandvaerker([FromBody] HaandVaerker haandVaerker)
        {
            using (var db = new DBContext())
            {
                var handyMan = await db.HaandVaerkers.FirstOrDefaultAsync(f => f.FirstName == haandVaerker.FirstName);
                if (handyMan != null)
                {
                    return handyMan;
                }
            }
            return null;
        }
        [HttpGet("GetAllHaandvaerker")]
        public async Task<ActionResult<List<HaandVaerker>>> GetAllHaandvaerker()
        {
            using (var db = new DBContext())
            {
                var handyMan = await db.HaandVaerkers.ToListAsync();
                if (handyMan != null)
                {
                    return handyMan;
                }
            }
            return null;
        }
    }
}
