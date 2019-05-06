import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import '../node_modules/bulma/css/bulma.min.css';
import './App.css';

import AppNavigation from './components/AppNavigation';
import AppContent from './components/AppContent';

function App() {
  return (
      <Router>
          <div className="App">
              <AppNavigation />
              <AppContent />
          </div>
      </Router>
  );
}

export default App;
