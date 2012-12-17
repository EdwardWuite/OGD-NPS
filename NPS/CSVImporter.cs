using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Entities;

namespace NPS
{
	public class CSVImporter
	{
		private string fileLocation;
		private Dictionary<string, AccountManager> AccountManagers;
		private Dictionary<string, Customer> customers;
		private Dictionary<string, Contact> contacts;
		private List<Project> projects; 

		public CSVImporter()
		{
			fileLocation = "D:\\docs\\NPS\\PROJECTEN.csv";

			AccountManagers = new Dictionary<string, AccountManager>();
			customers = new Dictionary<string, Customer>();
			contacts = new Dictionary<string, Contact>();
			projects = new List<Project>();
		}

		public void ReadFile()
		{
			var fileStream = new StreamReader(fileLocation);
			try
			{
				var line = "";
				var lineCounter = 0;
				while ((line = fileStream.ReadLine()) != null)
				{
					if (lineCounter != 0) //first line are just headers
					{
						ParseLine(line.Split(';'));
					}
					lineCounter++;
				}
			}
			catch (Exception)
			{
				//log error
			}
			finally
			{
				fileStream.Close();
			}
		}

		private void ParseLine(IList<string> line)
		{
			// 0 Achternaam;1 Einddatum;2 Behandelaar;3 Tussenvoegsels;4 Voornaam;5 Initialen;6 Achtervoegsel;7 Email adres;8 Projectnaam;9 Bedrijfsnaam
			var surName = line[0];
			var firstName = line[4];
			var prefix = line[3];
			var emailAddress = line[7];
			var customerName = line[9];
			var projectName = line[8];
			var accountManagerName = line[2];
			var finishDate = DateTime.Parse(line[1]);

			var contactName = AssembleContactName(firstName, prefix, surName);

			var accountManager = GetNewOrExistingAccountManager(accountManagerName);
			var customer = GetNewOrExistingCustomer(customerName);
			var contact = GetNewOrExistingContact(contactName, emailAddress, customer);
			var project = GetNewOrExistingProject(projectName, accountManager, customer, contact, finishDate);
		}

		private static string AssembleContactName(string firstName, string prefix, string surName)
		{
			var contactName = firstName;
			if (prefix != "")
			{
				contactName += " " + prefix;
			}
			contactName += " " + surName;

			return contactName;
		}

		private AccountManager GetNewOrExistingAccountManager(string accountManagerName)
		{
			if (AccountManagers.ContainsKey(accountManagerName))
			{
				return AccountManagers[accountManagerName];
			}

			var accountManager = new AccountManager {Name = accountManagerName};

			AccountManagers.Add(accountManagerName, accountManager);

			return accountManager;
		}

		private Customer GetNewOrExistingCustomer(string customerName)
		{
			if (customers.ContainsKey(customerName))
			{
				return customers[customerName];
			}
			var customer = new Customer { Name = customerName };

			customers.Add(customerName, customer);

			return customer;
		}

		private Contact GetNewOrExistingContact(string contactName, string emailAddress, Customer customer)
		{
			if (contacts.ContainsKey(contactName))
			{
				return contacts[contactName];
			}
			var contact = new Contact {Name = contactName, EmailAddress = emailAddress, Customer = customer};

			customer.Contacts.Add(contact);
			contacts.Add(contactName, contact);

			return contact;
		}

		private Project GetNewOrExistingProject(string projectName, AccountManager accountManager, Customer customer, Contact contact, DateTime finishDate)
		{
			foreach (var existingProject in projects.Where(existingProject => existingProject.Name == projectName && 
																			  existingProject.AccountManager.Name == accountManager.Name && 
																			  existingProject.Customer.Name == customer.Name &&
																			  existingProject.FinishDate == finishDate))
			{
				return existingProject;
			}

			var project = new Project
			{
				Name = projectName,
				Customer = customer,
				AccountManager = accountManager,
				Contact = contact,
				FinishDate = finishDate,
				Finished = false,
				Delayed = 0,
				LastChanged = DateTime.Now
			};

			customer.Projects.Add(project);
			accountManager.Projects.Add(project);
			contact.Projects.Add(project);

			return project;
		}
	}
}