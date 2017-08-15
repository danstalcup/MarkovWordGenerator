# MarkovWordGenerator

This is a console application that uses very simple Markov chains based on the probability that one letter follows another letter to randomly generate fictional English words.

Check it out by downloading [this ZIP](https://github.com/danstalcup/MarkovWordGenerator/blob/master/Markov%20Chain%20Word%20Gen.zip), which contains an executable and data file.
* It is a console application.
* It does not require any parameters, but can take up to three parameters.
* The first parameter (if provided) is number of words to generate. Default is `10`.
* The second parameter (if provided) is the seed used for randomizing. Default is system default.
* The third parameter (if provided) is the data source filepath. Default is `letterprobabilities.csv`
* Example: `./MarkovWord.exe 50 1234 data.csv`
* This would generate 50 words, using seed 1234, with letter data pulled from data.csv

Based off of this [reddit post](https://www.reddit.com/r/dataisbeautiful/comments/6rk2yr/letter_and_nextletter_frequencies_in_english_oc/).

He shared his data on [his github](https://github.com/Udzu/pudzu).

This is released under the [MIT License](https://opensource.org/licenses/MIT).

