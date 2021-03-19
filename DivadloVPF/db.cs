using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivadloVPF
{

    /*
     *  Database
     *  Create a Database connector
     */
    class DB
    {
        /* DB */
        public SQLiteConnection db;

        /* Constructor */
        public DB()
        {
            db = new SQLiteConnection("./data.db");
        }

        /*
         * Get number of columns
         */
        public int getCount(string table)
        {
            var result = db.Query<Theatre>("SELECT * FROM " + table);
            return result.Count;
        }

    }


    /*
     *  Database
     *  Theatre Table
     */

    class TheatreConnection : DB
    {

        /* @string table */
        private string table = "Theatre";

        /* Constructor */
        public TheatreConnection()
        {
            db.CreateTable<Theatre>();
            if (getCount(table) == 0)
            {

                //Creates a default data for Theatre
                setupDefaultData(10,15);
            }
        }

        /*
         * Update config X
         * @int x
         */
        public void updateX(int x)
        {
            db.Query<Theatre>("UPDATE " + table + " SET x = " + x);
        }

        /*
         * Update config Y
         * @int y
         */
        public void updateY(int y)
        {
            db.Query<Theatre>("UPDATE " + table + " SET y = " + y);
        }

        /* get a number of rows */
        public int getX()
        {
            var result = db.Query<Theatre>("SELECT * FROM " + table);
            return result[0].x;
        }

        /* get a number of columns */
        public int getY()
        {
            var result = db.Query<Theatre>("SELECT * FROM " + table);
            return result[0].y;
        }

        /*
         * Setup default data
         */
        private void setupDefaultData(int x, int y)
        {
            var result = db.Query<Theatre>("INSERT INTO " + table + " (x,y) VALUES (10,15)");
        }

    }

    /*
     *  Database
     *  Users Table
     */
    class UsersConnection : DB
    {

        /* @string table */
        private string table = "Users";
        
        /* Constructor */
        public UsersConnection()
        {   
            db.CreateTable<Users>();
        }

        /* Get a list from table */
        public List<Users> getAll()

        {
            var result = db.Query<Users>("SELECT * FROM "+ table);
            return result;
        }

        /*
         * Create a reservation
         * 
         * @string name
         * @string email
         * @int y
         * @int x
         * @int scene_id
         */
        public void createReservation(string name, string email, int x, int y,int scene_id)
        {
            db.Query<Users>(String.Format("INSERT INTO {0} (name, email, x, y, scene_id) VALUES ({1},{2},{3},{4},{5})", table,name, email, x,y,scene_id));

        }
        /*
         * Delete Reservation
         * @int id
         */
        public void deleteReservation(int id)
        {
            db.Query<Users>(String.Format("DELETE FROM {0} WHERE id = {1}"), table, id);

        }




    }

    /*
     *  Database
     *  Scene Table
     */
    class SceneConnection : DB
    {
        /* @string table */
        private string table = "Scene";
        
        /* Constructor */
        public SceneConnection()
        {
            db.CreateTable<Scene>();
        }

        /*
         *  Create a Scene
         *  @string name
         */
        public void CreateScene(string name)
        {
            db.Query<Users>("INSERT INTO " + table + " name VALUES ("+ name +")");
        }
        
        /*
         * Get all from Scene
         */

        public List<Scene> getAll()
        {
            var result = db.Query<Scene>("SELECT * FROM "+ table);
            return result;
        }

        /*
         * Get Scene By Id
         * @int id
         */
        public List<Scene> getById(int id)
        {
            var result = db.Query<Scene>("SELECT * FROM "+ table +" WHERE id = " + id);
            return result;
        }

        /*
         * Delete Scene By Id
         * @int id
         */
        public void deleteScene(int id)
        {
            db.Query<Scene>("DELETE FROM " + table + " WHERE id = "+ id); 
        }
    }


    /*
     *  Object
     *  Scene Table
     */
    class Scene
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string name { get; set; }
    }

    /*
     *  Object
     *  Scene Theatre
     */
    class Theatre
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public int x { get; set; }

        public int y { get; set; }
    }

    /*
     *  Object
     *  Scene Users
     */
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public int x { get; set; }

        public int y { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public int scene_id { get; set; }
    }
}
