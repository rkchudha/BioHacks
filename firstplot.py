import pandas as pd
import plotly.plotly as py
import plotly.graph_objs as go

# Read data from csv into pd.Dataframe

data = pd.read_table("Chr20FuncIntx.tsv")
data['EncodedTarget'], labels = data['Target'].factorize()
data['EncodedSource'], labels = data['Source'].factorize()

scores = (data['Score'] - data['Score'].mean()) / data['Score'].std()
data = data.drop(columns='Score')

layout = go.Layout(
    yaxis=dict(tickangle=90,
               showticklabels=True)
)

df = [go.Parcoords(
    line=dict(color=scores,
              colorscale='Greens',
              showscale=True,
              reversescale=True,
              cmin=0,
              cmax=2),

    dimensions=list([
        dict(tickvals=list(range(len(data['EncodedSource']))),
             ticktext=data['Source'],
             label='Source', values=data['EncodedSource']),

        dict(tickvals=list(range(len(data['EncodedTarget']))),
             ticktext=data['Target'],
             label='Target', values=data['EncodedTarget']),
    ])

)]

py.sign_in(username='NadaElnour', api_key='AfzxYrS7TQYqC1JCPJ9o')
fig = go.Figure(data=df, layout=layout)
py.plot(fig, filename='paracoords-advanced')
