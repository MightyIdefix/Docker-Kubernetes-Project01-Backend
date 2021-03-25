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
    public class VaerktoejController : ControllerBase
    {
        [HttpPut("AddVaerktoej")]
        public async Task<ActionResult<Vaerktoejskasse>> AddVaerktoej([FromBody] Vaerktoej vaerktoej)
        {
            using (var db = new DBContext())
            {
                var niceVaerktoejsKasse = await db.Vaerktoejskasses.FirstOrDefaultAsync(f => f.VaerktoejskasseId == vaerktoej.VaerktoejskasseId);
                //var epicVarktoej = await db.Vaerktoejs.FirstOrDefaultAsync(f => f.VaerktoejId == vaerktoej.VaerktoejId);
                if (niceVaerktoejsKasse != null)
                {
                    niceVaerktoejsKasse.Vaerktoejs.Add(vaerktoej);
                    await db.SaveChangesAsync();
                    return niceVaerktoejsKasse;
                }
            }
            return null;
        }

        [HttpPut("UpdateVaerktoej")]
        public async Task<ActionResult<Vaerktoej>> UpdateVaerktoej([FromBody] Vaerktoej vaerktoej)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var epicVarktoej = await db.Vaerktoejs.FirstOrDefaultAsync(f => f.VaerktoejId == vaerktoej.VaerktoejId);
                    if (epicVarktoej != null)
                    {
                        epicVarktoej = vaerktoej;
                        await db.SaveChangesAsync();
                        return epicVarktoej;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut("DeleteVaerktoej")]
        public async Task<ActionResult<Vaerktoej>> DeleteVaerktoej([FromBody] Vaerktoej vaerktoej)
        {
            using (var db = new DBContext())
            {
                var epicVarktoej = await db.Vaerktoejs.FirstOrDefaultAsync(f => f.VaerktoejId == vaerktoej.VaerktoejId);
                if (epicVarktoej != null)
                {
                    db.Remove(epicVarktoej);
                    await db.SaveChangesAsync();
                    return epicVarktoej;
                }
            }
            return null;
        }

        [HttpGet("GetVaerktoej")]
        public async Task<ActionResult<Vaerktoej>> GetVaerktoej([FromBody] Vaerktoej vaerktoej)
        {
            using (var db = new DBContext())
            {
                var epicVarktoej = await db.Vaerktoejs.FirstOrDefaultAsync(f => f.VaerktoejId == vaerktoej.VaerktoejId);
                if (epicVarktoej != null)
                {
                    return epicVarktoej;
                }
            }
            return null;
        }
    }
}
