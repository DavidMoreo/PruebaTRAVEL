using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTRAVEL.Interfaces;
using PruebaTRAVEL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTRAVEL.Services
{
    public class SqlServices : ISql
    {

        private readonly ConextModel _Context;

        public SqlServices(ConextModel newContext)
        {
            _Context = newContext;
        }

        public async Task<bool> DeleteGeneral(ModelGeneral generalRomove)
        {
            try
            {


                var result = _Context.editoriales.Select(s => s.id == generalRomove.Libros.esditoriales_id).ToList();
                var resultEditoriales = _Context.Libros.Select(s => s.esditoriales_id == generalRomove.Libros.esditoriales_id).ToList();
                var resultLibros = _Context.autores_has_libros.Select(s => s.libros_ISBN == generalRomove.Libros.IBN).ToList();


                _Context.Libros.Remove(generalRomove.Libros);
                _Context.editoriales.Remove(generalRomove.Editoriales);
                _Context.autores.Remove(generalRomove.Autor);
                _Context.autores_has_libros.Remove(generalRomove.Autor_has_libros);

                return await _Context.SaveChangesAsync() >= 3;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }


        public async Task<ModelGeneralList> GetAll()
        {
            var general = new ModelGeneralList();
            try
            {

                general.Libros = await _Context.Libros.ToListAsync();
                general.Autor = await _Context.autores.ToListAsync();
                general.Editoriales = await _Context.editoriales.ToListAsync();
                general.Autor_has_libros = await _Context.autores_has_libros.ToListAsync();
            }
            catch (Exception)
            {
                return null;
                throw;
            }

            return general;
        }

        public async Task<bool> SavedUpdateGeneral(ModelGeneral generalSave)
        {
            try
            {
                var autorResul = await _Context.autores.ToListAsync();
                var autorLibro = await _Context.Libros.ToListAsync();
                var autorEditorial = await _Context.editoriales.ToListAsync();
                int countAutor = autorResul.Count;
                int countLibro = autorLibro.Count;
                int countEditorial = autorEditorial.Count;
                if (autorEditorial != null) autorEditorial = autorEditorial.Where(s => s.id == generalSave.Editoriales.id).ToList();
                if (autorLibro != null) autorLibro = autorLibro.Where(s => s.IBN == generalSave.Libros.IBN).ToList();
                if (autorResul != null) autorResul = autorResul.Where(s => s.id == generalSave.Autor.id).ToList();
                if (generalSave.Autor_has_libros == null) generalSave.Autor_has_libros = new autores_has_libros();

                if (autorResul != null && autorResul.Count() <= 0)
                {
                    generalSave.Autor.id = countAutor + 1;
                    var resul = await _Context.autores.AddAsync(generalSave.Autor);
                    generalSave.Autor_has_libros.autores_id = generalSave.Autor.id;
                }
                else
                {

                    var resul = _Context.autores.Update(generalSave.Autor);

                }

                if (autorEditorial != null && autorEditorial.Count() <= 0)
                {
                    generalSave.Editoriales.id = countEditorial + 1;
                    var resul2 = await _Context.editoriales.AddAsync(generalSave.Editoriales);
                }
                else
                {
                    var resul2 = _Context.editoriales.Update(generalSave.Editoriales);
                }

                if (autorLibro != null && autorLibro.Count() <= 0)
                {
                    generalSave.Libros.IBN = countLibro + 1;
                    generalSave.Libros.esditoriales_id = generalSave.Editoriales.id;
                    var resul1 = await _Context.Libros.AddAsync(generalSave.Libros);
                    generalSave.Autor_has_libros.libros_ISBN = generalSave.Libros.IBN;

                }
                else
                {
                    var resul1 = _Context.Libros.Update(generalSave.Libros);

                }

                if (autorResul != null && autorResul.Count() <= 0 && autorLibro != null && autorLibro.Count() <= 0)
                {

                    var resul2 = await _Context.autores_has_libros.AddAsync(generalSave.Autor_has_libros);
                }

                return await _Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            { }
            return await _Context.SaveChangesAsync() > 0;
        }



    }
}
