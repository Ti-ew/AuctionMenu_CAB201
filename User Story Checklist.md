
1) Story: As the proprietor of the Auction House, I want to the system to provide a simple text-based user interface so clients will find it easy to use the system and it will be easy  for me to test the system.  
Acceptance Criteria:  
~~• When the program starts, a Main Menu dialog is displayed, with options that  
allow the user to (1) Register, (2) Sign In, or (3) Exit.  
• The user is required to supply a validated numeric value in the range 1–3, and  
the system takes subsequent action as appropriate.  
• All subsequent actions apart from Exit will be mediated by similarly structured  
menus, or by “question/answer/validation” style dialogs.  
• When Exit is selected, the program terminates gracefully.  
• Other selections are dealt with as indicated in the following stories.  

2. Story: As someone interested in buying or selling products I want to register as a client  with the online auction house so I can conduct business in the auction house.  
Acceptance criteria:
~~• A Registration dialog (available as an option on the Main Menu) allows the user  
to enter their name, email address, and password.  
• Name, email address, and password are validated according to criteria set out in  
Appendix 1, items 1, 2, and 4, respectively.  
• Email address must not be the same as any existing email address.  
• Client email address and password are preserved in the system for later use.  
• System must allow at least 100 clients to be registered simultaneously.  
• After registration is complete, control returns to the Main Menu.  

3. Story: As a client I want to use my existing email address and password to authenticate  myself with the system to access my private records and conduct transactions.  
Acceptance criteria:  
~~• A Sign In dialog (available as an option on the Main Menu) allows the user to  
enter email address and password to sign in to the system.  
• If the email address and password match those of an existing client, the program  
advances to the Client Menu dialog.  
• If the supplied credentials do no match those of any existing client, then an  
informative message to that effect is displayed.  
• In either event, control subsequently returns to the Main Menu.  

4. Story: As a client I want to be able to log out from the system so that the next person to use the system cannot access my private records or conduct transactions using my  account.  
Acceptance criteria:  
~~• A Log Out option is available in the Client Menu.  
• When selected, control returns to the Main Menu.  
• The user must re-authenticate to access their previously entered information. 

5. Story: As the proprietor of the auction house, I need all registered clients to provide  
their home address the first time they sign in so that products purchased through the  
auction house can be collected and delivered.  
Acceptance criteria:  
~~• The first time a client signs in, a Personal Details dialog is presented to collect  
their name and home address.  
• Home address is validated according to the rules set out in Appendix 1, item 3.  
• Once the home address has been recorded, and on all subsequent sign-ins, the  
client progresses to the Client Menu dialog to conduct business.

6. Story: As the proprietor of the auction house, I want the system to automatically save  the list of clients (together with their advertised products and details of any bids they  have placed on products) before the system closes, so client information will be  available for subsequent processing.  
Acceptance criteria:  
~~• All client data that has been entered into the system is saved to a text file in a  
suitable format, either immediately when it is accepted by the system, or when  
the system shuts down.  

7. Story: As the proprietor of the auction house, I want the system to automatically load  the list of clients (together with their advertised products and details of any bids they  have placed on products) when the system starts, so client information will not have to  be re-entered if the system powers down.  
Acceptance criteria:  
~~• Client data (including all clients, products, and bids) from previous sessions is  
available when the system starts.  

8. Story: As a client I want to advertise products in the auction house so I can sell them to  make some money.  
Acceptance criteria:  
~~• A Product Advertisement dialog (available as an option on the Client Menu)  
allows the client to add a new product to their list of advertised products.  
• Product information is validated according to the rules set out in Appendix 1,  
item 6.  

• The system must permit at least 100 products to be advertised by each client.  
9. Story: As a client I want to be able to display a list of all my currently advertised products  with information about bids that have been placed on each, if available, so I can see  what stock remain to be sold.  
Acceptance criteria:  
~~• A Product List dialog (available as an option on the Client Menu) displays all  
products advertised by the currently logged in client.  
• If no products have been advertised, an informative message to this effect is  
displayed is displayed to notify the user there are no matching results.  
• Products are displayed in a tabular form, with one product per row. Rows of the  
product list are numbered consecutively, starting at 1.  
• In addition to the row number, each row contains the product name,  
description, and price. If a bid is present, then details of the bid are displayed in  
a further set of three columns. Bid details consist of the name and email address  
of the highest bidder, and the amount of the highest bid. If no bid is present,
then a place-holder consisting of a single ‘-‘ (minus sign) appears in each column  
reserved for bid details.  
• The information is displayed in a single row, with fields separated by tab  
characters.  
• Products should be ranked in ascending order by name, then description, then  
price.  
• After the list is displayed, control returns to the Client Menu.  

10. Story: As a client I want to be able to use a search phrase to locate products that have  
been advertised for sale, so I can find products I might want to buy.  
Acceptance criteria:  
~~• A Product Search dialog (available as an option on the Client Menu) queries the  
user to get a search phrase.  
• Search phrase is validated according to the rule set out in Appendix 1, item 5.  
• Once a valid search phrase has been obtained, all products for sale by  
advertisers other than the current logged in client are queried to see if the  
search phrase appears in either product name or product description. If the  
search phrase is the special “ALL” keyword, then all products are listed.  
• If no products are found which match the search phrase, an informative  
message is displayed to notify the user there are no matching results.  
• If at least one product is found, then the search results are displayed in the same  
manner as specified in Story 9.  

11. Story: As a client I want to be able to bid a dollar amount for a product, so I can try to  buy it.  
Acceptance criteria:  
~~• After the Product Search dialog displays a list of products, a Bid Dialog queries  
the user to find out if they want to place a bid on any items on the list, by  
eliciting an answer which must be either “yes” or “no”.  
• If the response is affirmative, then the user is requested to supply a row number  
from the Product Search result list. The number must be validated as an integer  
within the range of row numbers appearing in the search result table.  
• The user is then requested to supply a bid amount:  
a. Bid amount is entered as a currency amount validated according to the  
rules set out in Appendix 1, item 7.  
b. Bid amount must be greater than the current highest bid to be  
acceptable.
c. Once a bid is initiated, the user must supply a valid currency amount  
which exceeds the value of the previous best bid before they can  
proceed.  
• The resulting highest bid, including the email address of the currently logged in  
client and the new bid amount is applied to the designated product, replacing  
any previous highest bid.  

12. Story: As a client I want to be able to view a list containing my products for which bids  have been placed, so I can see if anything can be sold.  
Acceptance Criteria:  
~~• A List Product Bids dialog (available from the Client Menu) is displayed, similar to  
the list introduced in Story 9. Instead of showing all products advertised by the  
current logged-in client, only those products for which another client has placed  
a bid are displayed.  
• If no products have a bid, an informative message to this effect is displayed is  
displayed to notify the user there are no matching results.  
• Otherwise, all products with a bid are displayed as per Story 9.  

13. Story: As a client I want to be able to sell one of my products to the current highest  bidder so I can realise a cash return.  
Acceptance Criteria:  
~~• After the List Product Bids dialog has displayed items, a Sell Product dialog  
queries the user to find out if they want to sell a product, by eliciting an answer  
which must be either “yes” or “no”.  
• If the response is affirmative:  
a. The user is requested to supply a row number from the Bid Product  
result list. The number must be validated as an integer which is equal to  
or greater than 1 and less than or equal to the maximum product row  
number appearing in the result table.  
b. The product in the designated row is then sold to the successful bidder,  
and a message is displayed to indicate how the product will be delivered.  
c. After completion of the operation, the product is no longer included in  
the current logged-in client’s Product List.  

14. Story: As a client, when I place a bid for a product, I want to be able to specify that I will  receive the product by one of two options – “click and collect”, or “home delivered” – so  I can get my new product and start using it.  
Acceptance Criteria:  
~~• After the Place Bid dialog completes, a Delivery Options dialog is used to obtain  
delivery information from the user.
• Two kinds of Delivery Option are available:  
a. “Click and Collect” allows the client to specify a Pickup Window – a  
period during which in which the product will be collected.  
If “Click and Collect” is selected, then a Pickup Window dialog is used to  
obtain the start- and end-time of the Pickup Window. Data requirements  
for the Pickup Window are set out in Appendix 1, item 8.  
b. “Home Delivery” allows the client to specify a delivery address (which  
may be different from their registered home address)  
If “Home Delivery” is selected, then a Home Delivery dialog is used to  
obtain a delivery address. The delivery address is obtained from the user  
according to the criteria for home address listed in Story 5. Validation  
rules for delivery address are set out in Appendix 1, item 3.  

15. Story: As a client, I want to see a list showing all products I have successfully purchased  so I can make my next trading decision.  
Acceptance Criteria:  
~~• A Purchased Items dialog (available from the Client Menu) is used to show  
details of all successful purchases in a tabular format.  
• If no products have been purchased, an informative message to this effect is  
displayed is displayed to notify the user there are no matching results.  
• Purchases are displayed in a tabular form, with one purchase per row. Rows of  
the product list are numbered consecutively, starting at 1.  
• In addition to the row number, each row contains: email address of the seller;  
product name; description; original listed price; amount paid for the product  
(this is the amount of the successful bid); and a synopsis of the delivery options.  
• The information is displayed in a single row, with fields separated by tab  
characters.  ~~
• Products should be ranked in ascending order by name, then description, then  
price
