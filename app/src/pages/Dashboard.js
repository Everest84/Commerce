import React, { Component } from 'react';
const BarChart = require('react-chartjs').Bar;

export default class Dashboard extends Component {
    render() {
        const profile = this.props.profile;

        let minDate = new Date();
        let maxDate = new Date();

        let labels = [];
        let datasets = [];

        for (let i = 0; i < profile.transactions.length; i++) {
            const processingDate = new Date(profile.transactions[i].processingDate);
            if (processingDate < minDate)
                minDate = processingDate;
            if (processingDate > maxDate)
                maxDate = processingDate;
        }

        let startingYear = minDate.getFullYear();
        let endingYear = maxDate.getFullYear();

        let dataset = {
            label: "Total spending",
            fillColor: "rgba(220,220,220,0.2)",
            strokeColor: "rgba(220,220,220,1)",
            pointColor: "rgba(220,220,220,1)",
            pointStrokeColor: "#fff",
            pointHighlightFill: "#fff",
            pointHighlightStroke: "rgba(220,220,220,1)",
            data: []
        };

        for (let i = startingYear; i <= endingYear; i++) {
            labels.push(i);
            let totalAmount = 0.00;
            for (let j = 0; j < profile.transactions.length; j++) {
                const transaction = profile.transactions[j];
                const processingDate = new Date(transaction.processingDate);
                if (processingDate.getFullYear() === i) {
                    const transactionId = transaction.transactionId;
                    const accountId = transaction.accountId;
                    const transactionType = transaction.transactionType === 0 ? "CR" : "DR";
                    const amount = transaction.amount;
                    const description = transaction.description;
                    if (transactionType === "DR") {
                        totalAmount += amount;
                    }
                }
            }
            dataset.data.push(totalAmount);
        }
        datasets.push(dataset);

        const chartData = {
            labels,
            datasets
        };
        const chartOptions = {};

        if (profile != null) {
            return (
                <div className="hero is-small">
                    <div className="hero-head">
                        <section className="section">
                            <h1 className="title is-size-1">Welcome back, {profile.user.firstName} {profile.user.lastName}.</h1>
                            <h2 className="subtitle is-size-3">Let's dive into your profile.</h2>
                        </section>
                    </div>
                    <div className="hero-body">
                        <div className="content content-inverse">
                            <h1 className="title">Your spending over the years</h1>
                            <BarChart data={chartData} options={chartOptions} width="600" height="300" />
                        </div>
                    </div>
                </div>
            )
        }
        return <p>Failed to render data</p>
    }
}