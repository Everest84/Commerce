import React, { Component } from 'react';
import AccountType from '../models/AccountType';

export default class Account extends Component {
    render() {
        const profile = this.props.profile;

        let currentAccount = null;
        let accountHtml = null;
        let tableHtml = [];
        let accountBalance = 0;

        profile.accounts.forEach(account => {
            if (account.accountId === this.props.match.params.id) {
                currentAccount = account;
                profile.transactions.forEach(transaction => {
                    if (transaction.accountId === account.accountId) {
                        const transactionId = transaction.transactionId;
                        const accountId = transaction.accountId;
                        const transactionType = transaction.transactionType === 0 ? "CR" : "DR";
                        const amountValue = transaction.amount;
                        if (transaction.transactionType === 0)
                            accountBalance += amountValue;
                        else
                            accountBalance -= amountValue;
                        let amount = transaction.amount.toString();
                        if (!amount.indexOf('.') > -1)
                            amount += '.00';
                        const description = transaction.description;
                        const processingDate = new Date(transaction.processingDate);

                        tableHtml.push(
                            <tr>
                                <td>{processingDate.getDate()}</td>
                                <td>{transactionType}</td>
                                <td>{amount}</td>
                                <td>{description}</td>
                            </tr>
                        )
                    }
                });
                accountHtml = (
                    <div className="card">
                        <div className="card-header pad">
                            <h1 className="title has-text-success">${accountBalance}</h1>
                        </div>
                        <div className="card-content">
                            <strong>Transactions</strong>
                            <table className="table is-striped is-hoverable is-fullwidth">
                                <thead>
                                <tr>
                                    <th>Processing Date</th>
                                    <th>Deposit/Withdrawal</th>
                                    <th>Amount</th>
                                    <th>Description</th>
                                </tr>
                                </thead>
                                <tbody>
                                {tableHtml};
                                </tbody>
                            </table>
                        </div>
                        <div className="card-footer">

                        </div>
                    </div>
                )
            }
        });

        if (profile != null) {
            return (
                <div className="hero is-small">
                    <div className="hero-head">
                        <section className="section">
                            <h1 className="title">{new AccountType(currentAccount.accountType).name}</h1>
                            <h2 className="subtitle">{currentAccount.accountNumber}</h2>
                        </section>
                    </div>
                    <div className="hero-body">
                        {accountHtml}
                    </div>
                </div>
            )
        }
        return <p>Failed to render data</p>
    }
}