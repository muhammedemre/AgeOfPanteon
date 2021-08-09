// Hello interviewer
// There is something that I need to tell you to make your job easier.
// - SampleScene is the scene that I built the game on.

// - I mainly focused on the requested functionality and when I reached it didn't crawl for more due to time issues.
// - Some UI elements like HP Bars are messing up with all other UI elements cuz of the display order. I didn't bother to fix them cuz of the time issues.
// Anyways nobody wanted to have HP bars, I just made them to be able to see the effect of the attacks.
//
// --- FACTORY PATTERN ---
// - I used the factory pattern to create the soldiers and buildings. You can find them under the "FactoriesForUnitTypes" folder.

// --- OBSERVER PATTERN ---
// - To implement the observer pattern I added a small feature to the game. The password feature... There is an Army object which has been designed
// for the observer pattern. The created soldiers subscribe to that army immediately and all soldiers have a "pocketForPassword" variable.
// When player clicks the change password button, Army generates a new password and notifies all subscribed soldiers about the new password.
// You can see the newly notified password under the soldierActor script on the soldierAnchor game object.

// --- SINGLETON PATTERN ---
// all managers are designed as singleton

// --- OBJECT POOLING ---
// Creating soldier system is designed with object pooling structure.

// --- INFINITE SCROLL VIEW ---
// all production and building creating buttons are in a panel which player can scroll infinitely.

// preparing this project took like 2 days in my tide schedule. Expecting your understanding about little mistakes :).
// Video of the game play : https://drive.google.com/file/d/1MgZ036IFo7CjKgP3IRM6vPNSnpZCvlKs/view
// Trello link of the project: https://trello.com/b/bDtjkKVG/ageofpanteon
