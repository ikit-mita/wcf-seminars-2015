using System;
using System.Collections.Generic;
using SharedModel;
using UsersClient.UserService;

namespace UsersClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchString = Console.ReadLine();

            var client = new UserServiceClient();
            List<User> users = client.FindUsers(searchString);

            if (users.Count == 0)
            {
                Console.WriteLine("NONE");
            }
            else
            {
                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
            }

            Console.ReadLine();
        }
    }
}
