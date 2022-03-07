import React from 'react';

import HomeIcon from '@mui/icons-material/Home';
import CreateIcon from '@mui/icons-material/Create';
import UpgradeIcon from '@mui/icons-material/Upgrade';
import ClearIcon from '@mui/icons-material/Clear';

export const SideBarData = [
    {
        title: "Home",
        icon: <HomeIcon/>,
        link: "/adm"
    },
    {
        title: "Cadastro",
        icon: <CreateIcon/>,
        link: "/cadastrar"
    },
    {
        title: "Alterar",
        icon: <UpgradeIcon/>,
        link: "/alterar"
    },
    {
        title: "Deletar",
        icon: <ClearIcon/>,
        link: "/excluir"
    }
]