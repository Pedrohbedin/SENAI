import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage/HomePage';
import LoginPage from './pages/LoginPage/LoginPage';
import ProdutoPage from './pages/ProdutoPage/ProdutoPage';


const routes = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route element={<HomePage/>} path="/" exact />
                <Route element={<LoginPage/>} path="/login" />
                <Route element={<ProdutoPage/>} path="/produtos" />
            </Routes>
        </BrowserRouter>
    );
};

export default routes;