# BeFit | fitNessMod
An IPA Plugin for BeatSaber to add a calorie counter/ tracker

## Current Features
1.  [x] Count Song Calories    - Displays calories adding up as you play beat saber songs
2.  [x] Count Session Calories - Everytime you open beat saber a new session starts from 0
3.  [x] Count Daily Calories   - Based on the current date. *Known Bug with playing during date changes*
4.  [x] Count All Calories     - Counts calories since mod has been installed. *Will most likely be removed at later date.*
5.  [x] Last Song Played       - Shows calories from last song played.

## Future Improvments
Things to add:
* [ ] Calories based on vertical movment of headset
* [ ] Larger distance between blocks has higher coefficient.
* [ ] A seperate menu composed of:
  * [ ] Toggle labels visible on menu screen
  * [ ] Setting daily Calorie goals
  * [ ] Setting Weekly Calorie Goals
  * [ ] Implement weightloss playlists
  * [ ] View Calorie Statistics
  * [ ] Include a pounds to calories value, 3500 calories ~= 1 lbs

## Important!
There is no way that his mod is accurate! However, I have been trying to set the amount of calories calculated to be lower than what I imagine they should be. Please let me know if you find the calorie counting process to not be fair or to forgiving.

## Install
Make sure your game is patched with IPA, [Beat Saber Mod Installer](https://github.com/Umbranoxio/BeatSaberModInstaller/releases) will do this for you. Then,
1.  Download the [BeFit Mod latest release here]()
2.  Copy the fitNessMod.dll file to the Beat Saber Plugins folder
3.  That's it! Start the game and beat some calories to death! (I am aware that's not how that works)

## How it works
Currently it is really simple. Take a look at the source code and it won't take long to understand.

### How do the calories get calculated?
I played a less fun game that had a calorie calculator and I did an extreme session where I found the calories for a 12 minute period. I then used an element from the score controller and gave my best estimates to a multiplier that was accurate.


  

