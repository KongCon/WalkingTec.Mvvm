﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Demo.Models;


namespace WalkingTec.Mvvm.Demo.ViewModels.MajorVMs
{
    public class MajorDetailListVM : BasePagedListVM<Major, MajorSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Major", GridActionStandardTypesEnum.AddRow, "新建","", dialogWidth: 800),
                this.MakeStandardAction("Major", GridActionStandardTypesEnum.RemoveRow, "删除","", dialogWidth: 800),
            };
        }

        protected override IEnumerable<IGridColumn<Major>> InitGridHeader()
        {
            return new List<GridColumn<Major>>{
                this.MakeGridHeader(x => x.MajorCode).SetEditType(EditTypeEnum.TextBox),
                this.MakeGridHeader(x => x.MajorType).SetEditType(EditTypeEnum.ComboBox,typeof(MajorTypeEnum).ToListItems(null,true)),
                this.MakeGridHeader(x => x.MajorName).SetEditType(EditTypeEnum.TextBox),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Major> GetSearchQuery()
        {
            var query = DC.Set<Major>()
                .Where(x=>Searcher.SchoolId == x.SchoolId)
                .OrderBy(x => x.ID);
            return query;
        }

    }

}
