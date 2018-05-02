from sklearn.pipeline import Pipeline
from sklearn.feature_extraction.text import TfidfTransformer
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.naive_bayes import MultinomialNB
from sklearn.linear_model import SGDClassifier
from sklearn.model_selection import GridSearchCV, train_test_split

development = False
x_train=[]
y_train=[]
file_name = 'document_classification.train.txt' # 'trainingdata.txt'
with open(file_name) as f:
    l = f.readline()
    for line in f:
        temp = line.split()
        n=len(temp)
        y_train.append(int(temp[0])) #contains category of each text
        x_train.append( " ".join(temp[1:n]) ) #contains text#rather organize it based on category

if development:
    X_train, X_test, Y_train, Y_test = train_test_split(x_train, y_train,
                                                      stratify=y_train,
                                                      random_state=42,
                                                      test_size=0.1, shuffle=True)
    print([len(x) for x in [X_train, X_test, Y_train, Y_test]])
else:
    X_train, Y_train = x_train, y_train
    #print([len(x) for x in [X_train, Y_train]])

#print('Train data:', X_train[:2])
text_clf = Pipeline([('vect', CountVectorizer()),('clf', SGDClassifier(
    loss='hinge', penalty='l2', alpha=1e-3, max_iter=18, random_state=42))])
text_clf = text_clf.fit(X_train, Y_train)

if development:
    print(text_clf.score(X_test, Y_test))
else:
    #line_num = int(input())
    x_test=[]
    x_test = ['This is a document', 'this is another document', 'documents are seperated by newlines']
    #[x_test.append(input()) for i in range(line_num)]
    #print('test lines - len(x_test):', line_num, len(x_test), x_test)

    preds = text_clf.predict(x_test)
    [print(p) for p in preds]
