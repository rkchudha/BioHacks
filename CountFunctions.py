if __name__ == '__main__':

    file_read = open("Chr20GWAStraits.tsv", "r")
    file_write = open("FunctionCount.csv", "w")

    # dictionary string to int: [unfavourable_count, favourable_count]
    genes_all = {}
    for line in file_read:
        gene = line.split()[0]
        if gene in genes_all:
            genes_all[gene] += 1
        else:
            genes_all[gene] = 1
    file_write.write("Gene,FunctionCount\n")
    for gene in genes_all:
        file_write.write(gene + "," + str(genes_all[gene]) + "\n")
