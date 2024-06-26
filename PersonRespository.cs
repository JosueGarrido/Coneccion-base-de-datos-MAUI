﻿using jgarrido_s5.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jgarrido_s5
{
    public class PersonRespository
    {
        string _dbPath;
        private SQLite.SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();

        }

        public PersonRespository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void addNewPerson(string nombre) {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");

                Persona person = new() { Name = nombre };
                result = conn.Insert(person);

                StatusMessage = string.Format("{0} record(s) added (Nombre: {1})", result, nombre);
            }catch(Exception ex) 
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", nombre, ex.Message);
            }
                
        }

        public List<Persona> GetAllPeople() 
        {  
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex) 
            { 
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<Persona>();
        }

        public void EditPerson(Persona persona)
        {
            try
            {
                Init();

                if (persona is null)
                    throw new Exception("Persona requerida");

                conn.Update(persona);

                StatusMessage = string.Format("{0} record(s) updated (Nombre: {1})", 1, persona.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update {0}. Error: {1}", persona.Name, ex.Message);
            }
        }

        public void DeletePerson(Persona persona)
        {
            try
            {
                Init();

                if (persona is null)
                    throw new Exception("Persona requerida");

                conn.Delete(persona);

                StatusMessage = string.Format("{0} record(s) deleted (Nombre: {1})", 1, persona.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", persona.Name, ex.Message);
            }
        }

    }
}
