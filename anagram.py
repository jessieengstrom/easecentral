from string import ascii_lowercase as al

def get_words(file):
    """Open and parse word file."""

    words = []

    with open(file) as my_file:
        for line in my_file:
            line = line.rstrip()
            words.append(line)

    return words


def count_words(word):
    """Get the count of a word."""

    # give each character a weight
    chars = {x:i for i, x in enumerate(al, 1)}

    count = 0

    # calculate the weight of a word
    for c in word:
        count += chars[c]

    return count



def find_anagrams(file):
    """Find the anagrams in a list of words."""

    words = get_words(file)
    words_values = {}
    anagrams = []

    # call the count words function for each word and add them to the word values dictionary
    for word in words:
        count = count_words(word)
        if words_values.get(count):
            words_values[count].append(word)
        else:
            words_values[count] = [word]
    # look at each count and if it has more that one word associated with it
    # then return the anagrams in a list of tuples
    for count in words_values:
        if len(words_values[count]) > 1:
            anagrams.append(tuple(words_values[count]))

    return anagrams


print find_anagrams('./words.txt')

