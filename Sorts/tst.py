import operator
def retrieveMostFrequentlyUsedWords(literatureText, wordsToExclude):
    # WRITE YOUR CODE HERE
    words = literatureText.split()
    excl_word_dic = set(wordsToExclude)
    word_dic = {}
    for word in words:
        if word not in excl_word_dic:
            if word in word_dic :
                word_dic[word] += 1
            else:
                word_dic[word] = 1
    sorted_word_count = sorted(word_dic.items(), key=operator.itemgetter(1), reverse=True)
    max_count = sorted_word_count[0][1]
    return [w for (w, c) in sorted_word_count if c == max_count]

print (range(0,-1,-1))
literatureText = 'It would be good to review our 14 leadership principals, because the survey will focus around those. This portion of the assessment is equally as important as the technical component. Have a look at our 14 leadership principles (link below) and think about experiences in your career that pertain to each principle.'
wordsToExclude = ['a', 'be', 'the', 'to', 'our', '14', 'leadership', 'as']
print( retrieveMostFrequentlyUsedWords(literatureText, wordsToExclude))

t = {1: 'a', 4: 'sdf', 0: 'asd'}
s = (t)

print(s)