using DataShelfMaster.Context;
using DataShelfMaster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShelfMaster.Services
{
    public class PersonnelService
    {
        #region Personnel
        public void CreatePersonnel(Personnel request)
                {
                    try
                    {
                        using (var _context = new ApplicationDBContext())
                        {
                            Personnel personnel = new Personnel()
                            {
                                Name = request.Name,
                                Username = request.Username,
                                Password = request.Password,
                                FkRole = request.FkRole
                            };
                            _context.Personnels.Add(personnel);
                            _context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Bug: ", ex);
                    }
                }
        public List<Personnel> ReadPersonnel()
        {
            try
            {
                var _context = new ApplicationDBContext();
                var personnel = _context.Personnels.Include(x=>x.Roles).ToList();
                return personnel;
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public void UpdatePersonnel(Personnel request)
                {
                    try
                    {
                        using (var _context = new ApplicationDBContext())
                        {
                            var personnel = _context.Personnels.Where(s => s.IdPersonnel == request.IdPersonnel).First<Personnel>();
                            personnel.Name = request.Name;
                            personnel.Username = request.Username;
                            personnel.Password = request.Password;
                            personnel.FkRole = request.FkRole;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Bug: ", ex);
                    }
                }
        public void DeletePersonnel(Personnel request)
                {
                    try
                    {
                        using (var _context = new ApplicationDBContext())
                        {
                            var personnel = _context.Personnels.FirstOrDefault(s => s.IdPersonnel == request.IdPersonnel);
                            _context.Personnels.Remove(personnel);
                            _context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Bug: ", ex);
                    }
                }
        //- - - Adicional - - -//
        public List<Personnel> SearchStudents(Personnel request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var personnel = _context.Personnels.Where(s=>
                s.IdPersonnel==request.IdPersonnel||
                s.Name==request.Name||
                s.Username==request.Username||
                s.Password==request.Password).ToList();
                return personnel;
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public void UpdatePassword(Personnel request)
                {
                    using (var _context = new ApplicationDBContext())
                    {
                        var personnel = _context.Personnels.Where(s => s.IdPersonnel == request.IdPersonnel).First<Personnel>();
                        personnel.Password = request.Password;
                    }
                }
        public void UpdateRole(Personnel request)
                {
                    using(var _context = new ApplicationDBContext())
                    {
                        var personnel = _context.Personnels.Where(s => s.IdPersonnel == request.IdPersonnel).First<Personnel>();
                        personnel.FkRole = request.FkRole;
                    }
                }
        public string ValidatePersonnel(Personnel request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var validate = _context.Personnels.Where(s => s.Username == request.Username).ToList();
                return validate.Count.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public string ValidateUser(Personnel request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var validate = _context.Personnels.Where(s => s.Username == request.Username&&s.Password==request.Password).ToList();
                return validate.Count.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public Personnel ValidateRole(string Username)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var validate = _context.Personnels.Where(s => s.Username == Username).FirstOrDefault();
                return validate;
            }
            catch (Exception ex)
            {

                throw new Exception("Bug: ",ex);
            }
        }
        public List<Role> ReadRole()
        {
            try
            {
                var _context = new ApplicationDBContext();
                var role = _context.Roles.ToList();
                return role;
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        #endregion

        #region Solicitudes
        public void CreateSolicitudes(Solicitude request)
        {
            try
            {
                using (var _context = new ApplicationDBContext())
                {
                    Solicitude solicitude = new Solicitude()
                    {
                        FkMatric = request.FkMatric,
                        FkISBN = request.FkISBN,
                        DateSolicitude = request.DateSolicitude,
                        Observation = request.Observation,
                        Status = request.Status,
                        DateDevolution = DateTime.Now.AddDays(7)
                    };
                    _context.Solicitudes.Add(solicitude);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public List<Solicitude> ReadSolicitudes()
        {
            try
            {
                var _context = new ApplicationDBContext();
                var solicitude = _context.Solicitudes.Include(x => x.Students).Include(y => y.Books).ToList();
                return solicitude;
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public void UpdateSolicitudes(Solicitude request)
        {
            try
            {
                using (var _context = new ApplicationDBContext())
                {
                    var solicitude = _context.Solicitudes.Where(s => s.IdSolicitude == request.IdSolicitude).First<Solicitude>();
                    solicitude.FkMatric = request.FkMatric;
                    solicitude.FkISBN = request.FkISBN;
                    solicitude.Observation = request.Observation;
                    solicitude.Status = request.Status;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public void DeleteSolicitudes(Solicitude request)
        {
            try
            {
                using (var _context = new ApplicationDBContext())
                {
                    var solicitude = _context.Solicitudes.FirstOrDefault(s => s.IdSolicitude == request.IdSolicitude);
                    _context.Solicitudes.Remove(solicitude);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        //- - - Adicional - - -//
        public List<Solicitude> SearchSolicitude(Solicitude request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var solicitude = _context.Solicitudes.Where(s =>
                s.FkMatric == request.FkMatric ||
                s.FkISBN == request.FkISBN ||
                s.DateSolicitude == request.DateSolicitude ||
                s.Observation == request.Observation ||
                s.Status == request.Status ||
                s.DateDevolution==request.DateDevolution).ToList();
                return solicitude;
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        #endregion
    }
}
