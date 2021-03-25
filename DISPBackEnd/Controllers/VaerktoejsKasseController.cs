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
    public class VaerktoejsKasseController : ControllerBase
    {
        [HttpPut("AddVaerktoejKasse")]
        public async Task<ActionResult<Vaerktoejskasse>> AddVaerktoejsKasse([FromBody] Vaerktoejskasse vaerktoejskasse)
        { 
            try
            {
                using (var db = new DBContext())
                {
                    var handyMan = await db.HaandVaerkers.FirstOrDefaultAsync(f => f.FirstName == vaerktoejskasse.VTKEjesAf);
                    if (handyMan != null)
                    {
                        handyMan.Vaerktoejskasse = vaerktoejskasse;
                        vaerktoejskasse.HaandVaerkerId = handyMan.HaandVaerkerId;
                        db.Vaerktoejskasses.Add(vaerktoejskasse);
                        await db.SaveChangesAsync();
                        return handyMan.Vaerktoejskasse;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut("UpdateVaerktoejskasse")]
        public async Task<ActionResult<Vaerktoejskasse>> UpdateVaerktoejskasse([FromBody] Vaerktoejskasse vaerktoejskasse)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var niceVaerktoejsKasse = await db.Vaerktoejskasses.FirstOrDefaultAsync(f => f.VTKEjesAf == vaerktoejskasse.VTKEjesAf);
                    if (niceVaerktoejsKasse != null)
                    {
                        niceVaerktoejsKasse = vaerktoejskasse;
                        await db.SaveChangesAsync();
                        return niceVaerktoejsKasse;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut("DeleteVaerktoejkasse")]
        public async Task<ActionResult<Vaerktoejskasse>> DeleteVaerktoej([FromBody] Vaerktoejskasse vaerktoejskasse)
        {
            using (var db = new DBContext())
            {
                var niceVaerktoejsKasse = await db.Vaerktoejskasses.FirstOrDefaultAsync(f => f.VTKEjesAf == vaerktoejskasse.VTKEjesAf);
                if (niceVaerktoejsKasse != null)
                {
                    db.Remove(niceVaerktoejsKasse);
                    await db.SaveChangesAsync();
                    return niceVaerktoejsKasse;
                }
            }
            return null;
        }

        [HttpGet("GetVaerktoejskasse")]
        public async Task<ActionResult<Vaerktoejskasse>> GetVaerktoejskasse([FromBody] Vaerktoejskasse vaerktoejskasse)
        {
            using (var db = new DBContext())
            {
                var niceVaerktoejsKasse = await db.Vaerktoejskasses.FirstOrDefaultAsync(f => f.VaerktoejskasseId == vaerktoejskasse.VaerktoejskasseId);
                if (niceVaerktoejsKasse != null)
                {
                    return niceVaerktoejsKasse;
                }
            }
            return null;
        }
    }
}
