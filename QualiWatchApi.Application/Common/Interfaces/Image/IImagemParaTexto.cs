﻿using QualiWatchApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiWatchApi.Application.Common.Interfaces.Image;

public interface IImagemParaTexto
{
    public List<ImageResponse> PegarValidade(string base64);
    public List<ImageResponse> PegarTexto(string base64);

}
