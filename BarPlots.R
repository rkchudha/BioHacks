#Interaction Frequency
#Using our gene-gene interaction parallel plot in tandem with the computational analysis
#of the interactions, we can determine which genes are prominent.

#Read in the chromosome 20 gene data.
gene_info <- read.delim('Chr20GeneData.tsv')

#Read in the chromosome 20 gene interactions.
interactions <- read.delim('Chr20FuncIntx.tsv')

#Add another column to the gene info dataframe calculating the center of the gene sequence.
gene_info$coordinates <- (gene_info$end - gene_info$start)/2


#Count the number of unique gene-gene interactions.
number_of_interactions <- table(interactions$a)

#Convert to df for manipulation. 
number_of_interactions <- as.data.frame(number_of_interactions)

#Calculate the mean frequency.
mean(number_of_interactions$Freq)


high_frequency_interactions <-  number_of_interactions[number_of_interactions$Freq > 
                                                           mean(number_of_interactions$Freq),]

library(plotly)
P <- plot_ly(
  x = high_frequency_interactions$Var1,
  y = high_frequency_interactions$Freq,
  name = "High Frequency Interactions",
  type = "bar"
)

P

#Based on that graph we can see that the highest number of interactions involve AURKA, DEFB118, 
#DEFB124, DEFB128, DEFB129, and PROKR2. There were others fairly close by which can be further 
#explored. We used this data in conjunction with the Human Protein Atlas to measure RNA expression
#scores and highlight them on the human body. 




