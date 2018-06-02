import sys

def get_words(file):
    """Open and parse word file."""

    words = []

    with open(file) as my_file:
        for line in my_file:
            line = line.rstrip()
            words.append(line)

    return words


def find_anagrams(file):
    """Find the anagrams in a list of words."""

    words = get_words(file)
    sorted_words = {}

    for word in words:
        sort = str(sorted(word))
        if sorted_words.get(sort):
            sorted_words[sort].append(word)
        else:
            sorted_words[sort] = [word]

    for sorted_word, anagrams in sorted_words.iteritems():
        if len(anagrams) > 1:
            print tuple(anagrams)


find_anagrams(sys.argv[1])

