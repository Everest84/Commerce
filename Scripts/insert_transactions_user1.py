import csv

userId = 'ABEB2DD6-EA4D-4B70-9CF8-4D3B9D34BC0F'

output = open("insert_transactions_user1.txt", "w")
with open('user1data.csv') as csv_file:
    csv_reader = csv.reader(csv_file, delimiter=',')
    line_count = 0
    current_account = ''
    for row in csv_reader:
        if line_count > 0:
            accountType = row[0]
            accountNumber = row[1]
            processingDate = row[2].replace('-','') + ' 12:00:00 AM'
            balance = row[3]
            transactionType = 0
            if row[4] == 'CR':
                transactionType = 0
            else:
                transactionType = 1
            amount = row[5].replace('$','')
            description = row[6]

            accountId = ''
            if accountType == 'Checking':
                accountId = '184F8A7F-D142-40DF-A503-0A5AA89EF5A1'
            elif accountType == 'Savings':
                accountId = 'C11D1CC6-CB28-4694-91E2-3C7DDDE332C3'
            else:
                accountId = '7EFA8809-94E4-4AD8-A7CB-09963FAEEC5E'

            if len(balance) > 0:
                output.write(f'DECLARE @accountId UNIQUEIDENTIFIER = \'{accountId}\';\n\
DECLARE @transactionType INT = 0;\n\
DECLARE @amount DECIMAL(19,4) = {balance};\n\
DECLARE @description VARCHAR(MAX) = \'Account opening\';\n\
DECLARE @processingDate DateTime = \'{processingDate}\';\n\
INSERT INTO [dbo].[Transaction]\n\
VALUES (NEWID(), @accountId, @transactionType, @amount, @description, @processingDate);\n')
            else:
                output.write(f'DECLARE @accountId UNIQUEIDENTIFIER = \'{accountId}\';\n\
DECLARE @transactionType INT = {transactionType};\n\
DECLARE @amount DECIMAL(19,4) = {amount};\n\
DECLARE @description VARCHAR(MAX) = \'{description}\';\n\
DECLARE @processingDate DateTime = \'{processingDate}\';\n\
INSERT INTO [dbo].[Transaction]\n\
VALUES (NEWID(), @accountId, @transactionType, @amount, @description, @processingDate);\n')
            output.write('\nGO\n\n')
        line_count += 1
output.close()

