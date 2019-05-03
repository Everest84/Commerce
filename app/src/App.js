import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import '../node_modules/bulma/css/bulma.min.css';
import './App.css';

import Navigation from './components/Navigation';

function App() {
  return (
    <Router>
        <div className="App">
            <div className="App-navigation">
                <nav className="navbar is-info" role="navigation">
                    <div className="navbar-brand">
                        <div className="navbar-item">
                            <strong className="has-text-white">PocketChange</strong>
                        </div>
                    </div>
                </nav>
                <section className="section">
                    <Navigation/>
                </section>
            </div>
            <div className="App-content">
                <header className="App-content-header">
                    <nav className="navbar is-info" />
                </header>
                <main className="App-content-main">

                </main>
                <footer className="App-content-footer">

                </footer>
            </div>
        </div>
    </Router>
  );
}

export default App;
