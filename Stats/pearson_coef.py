from scipy.stats import spearmanr, pearsonr

ps = [int(x) for x in '15  12  8   8   7   7   7   6   5   3'.split()]
hs = [int(x) for x in '10  25  17  11  13  17  20  13  9   15'.split()]

print (spearmanr(ps, hs))
print (spearmanr(hs, ps))
print(pearsonr(ps, hs))
print(pearsonr(hs, ps))

# Manual calculation:
Score1 = ps
Score2 = hs

m1 = (sum(Score1)/len(Score1))
m2 = (sum(Score2)/len(Score1))

Score1_normalized = [x - m1 for x in Score1]
Score2_normalized = [x - m2 for x in Score2]

n1 = sum([x * y for x,y in zip(Score1_normalized, Score2_normalized)])

Score1 = sum([(x-m1)**2 for x in Score1])
Score2 = sum([(x-m2)**2 for x in Score2])

n2 = (Score1**(1/2))*(Score2**(1/2))

r = n1/n2

print (round(r,3))